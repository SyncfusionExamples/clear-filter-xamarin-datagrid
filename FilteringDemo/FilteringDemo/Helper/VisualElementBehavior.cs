﻿using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FilteringDemo
{
	public class VisualElementBehavior : Behavior<VisualElement>
	{ 
		public SfDataGrid DataGrid { get; set; }
		public Picker OptionListPicker { get; set; }
		public ViewModel viewModels { get; set; }
		public SearchBar Searchbar { get; set; }

		protected override void OnAttachedTo(VisualElement bindable)
		{
			viewModels.filtertextchanged = OnFilterChanged;
			if (bindable as SearchBar != null)
            {
				(bindable as SearchBar).TextChanged += OnFilterTextChanged;

			}
			else if(bindable as Picker !=null)
            {
				
				if((bindable as Picker).Title== "OptionsList")
                {
					(bindable as Picker).SelectedIndexChanged += OnFilterOptionsChanged;

				}
				else
                {
					(bindable as Picker).SelectedIndexChanged += OnColumnsSelectionChanged;
                }
            }
			base.OnAttachedTo(bindable);

		}
		void OnFilterTextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue == null)
				viewModels.FilterText = "";
			else
				viewModels.FilterText = e.NewTextValue;
		}
		void OnFilterOptionsChanged(object sender, EventArgs e)
		{
			Picker newPicker = (Picker)sender;
			if (newPicker.SelectedIndex >= 0)
			{
				viewModels.SelectedCondition = newPicker.Items[newPicker.SelectedIndex];
				if (Searchbar.Text != null)
					OnFilterChanged();
					
			}
		}
		void OnFilterChanged()
		{
			if (DataGrid.View != null)
			{
				this.DataGrid.View.Filter = viewModels.FilerRecords;
				this.DataGrid.View.RefreshFilter();
			}
		}

		void OnColumnsSelectionChanged(object sender, EventArgs e)
		{
			Picker newPicker = (Picker)sender;
			viewModels.SelectedColumn = newPicker.Items[newPicker.SelectedIndex];
			if (viewModels.SelectedColumn == "All Columns")
			{
				viewModels.SelectedCondition = "Contains";
				OptionListPicker.IsVisible = false;
				this.OnFilterChanged();
			}
			else
			{
				OptionListPicker.IsVisible = true;
				foreach (var prop in typeof(OrderInfo).GetProperties())
				{
					if (prop.Name == viewModels.SelectedColumn)
					{
						if (prop.PropertyType == typeof(string))
						{
							OptionListPicker.Items.Clear();
							OptionListPicker.Items.Add("Contains");
							OptionListPicker.Items.Add("Equals");
							OptionListPicker.Items.Add("NotEquals");
							if (this.viewModels.SelectedCondition == "Equals")
								OptionListPicker.SelectedIndex = 1;
							else if (this.viewModels.SelectedCondition == "NotEquals")
								OptionListPicker.SelectedIndex = 2;
							else
								OptionListPicker.SelectedIndex = 0;
						}
						else
						{
							OptionListPicker.Items.Clear();
							OptionListPicker.Items.Add("Equals");
							OptionListPicker.Items.Add("NotEquals");
							if (this.viewModels.SelectedCondition == "Equals")
								OptionListPicker.SelectedIndex = 0;
							else
								OptionListPicker.SelectedIndex = 1;
						}
					}
				}
			}
		}

	}
}
