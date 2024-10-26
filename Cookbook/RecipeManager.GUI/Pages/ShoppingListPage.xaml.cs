﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using CookBook.RecipeManager.GUI.Models;
using RecipeManager.DataBase;
using RecipeManager.BusinessLogic;

namespace CookBook.RecipeManager.GUI.Pages
{
    public partial class ShoppingListPage : Page
    {
        private ObservableCollection<ShoppingListItem> _shoppingItems;
        private readonly ShoppingListDatabase _shoppingListDatabase;
        private readonly ShoppingListMerger _merger = new ShoppingListMerger();

        public ShoppingListPage()
        {
            InitializeComponent();
            _shoppingListDatabase = new ShoppingListDatabase("shoppingList.json");
            LoadShoppingList();
        }

        private void LoadShoppingList()
        {
            var loadedItems = _shoppingListDatabase.LoadShoppingList();
            _shoppingItems = new ObservableCollection<ShoppingListItem>(loadedItems);
            shoppingList.ItemsSource = _shoppingItems;
        }

        private void SaveShoppingList()
        {
            _shoppingListDatabase.SaveShoppingList(_shoppingItems.ToList());
        }

        public void AddToShoppingList(string ingredient)
        {
            // 使用 ParseIngredient 处理输入的配料字符串
            var newItem = new ShoppingListItem(ingredient);

            var existingItem = _shoppingItems.FirstOrDefault(item =>
                item.Name.Equals(newItem.Name, StringComparison.OrdinalIgnoreCase));

            if (existingItem != null)
            {
                existingItem.IsSelected = true;
                // 可以在这里处理数量合并逻辑
                if (double.TryParse(existingItem.Quantity.Split(' ')[0], out double existingQuantity) &&
                    double.TryParse(newItem.Quantity.Split(' ')[0], out double newQuantity))
                {
                    existingItem.Quantity = $"{existingQuantity + newQuantity} {existingItem.Quantity.Split(' ')[1]}";
                }
            }
            else
            {
                _shoppingItems.Add(newItem);
            }
            RefreshShoppingList();
            SaveShoppingList();
        }

        public void AddIngredientsToShoppingList(List<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                AddToShoppingList(ingredient);
            }
            RefreshShoppingList();
            SaveShoppingList();
        }

        private void RefreshShoppingList()
        {
            var temp = shoppingList.ItemsSource;
            shoppingList.ItemsSource = null;
            shoppingList.ItemsSource = temp;
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            txtNewItemName.Text = "";
            txtNewItemQuantity.Text = "1";
            addItemPopup.IsOpen = true;
        }

        private void BtnConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewItemName.Text))
            {
                var quantity = string.IsNullOrWhiteSpace(txtNewItemQuantity.Text) ? "1" : txtNewItemQuantity.Text;
                var ingredient = $"{quantity} {txtNewItemName.Text.Trim()}";
                AddToShoppingList(ingredient);
                addItemPopup.IsOpen = false;
            }
        }

        private void BtnCancelAdd_Click(object sender, RoutedEventArgs e)
        {
            addItemPopup.IsOpen = false;
        }

        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is ShoppingListItem item)
            {
                _shoppingItems.Remove(item);
                SaveShoppingList();
            }
        }

        private void Quantity_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void BtnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = _shoppingItems.Where(item => item.IsSelected).ToList();
            if (selectedItems.Any())
            {
                string shoppingList = "Shopping List:\n\n";
                foreach (var item in selectedItems)
                {
                    shoppingList += $"- {item.Quantity} {item.Name}\n";
                }

                try
                {
                    Clipboard.SetText(shoppingList);
                    MessageBox.Show("Shopping list copied to clipboard!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying to clipboard: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No items selected to copy.");
            }
        }

        private void BtnSaveAsText_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = _shoppingItems.Where(item => item.IsSelected).ToList();
            if (!selectedItems.Any())
            {
                MessageBox.Show("No items selected to save.");
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = "txt",
                FileName = "ShoppingList.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string shoppingList = "Shopping List:\n\n";
                    foreach (var item in selectedItems)
                    {
                        shoppingList += $"- {item.Quantity} {item.Name}\n";
                    }

                    File.WriteAllText(saveFileDialog.FileName, shoppingList);
                    MessageBox.Show("Shopping list saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}");
                }
            }
        }

        private void BtnMergeItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentItems = _shoppingItems.ToList();
                var mergedItems = _merger.MergeItems(currentItems);

                _shoppingItems.Clear();
                foreach (var item in mergedItems)
                {
                    _shoppingItems.Add(item);
                }

                SaveShoppingList();
                MessageBox.Show("Shopping list items merged successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error merging items: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Quantity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is ShoppingListItem item)
            {
                // 可以在这里添加数量格式验证
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    item.Quantity = textBox.Text;
                    SaveShoppingList();
                }
            }
        }

        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // 可以在这里添加实时数量验证
                string text = textBox.Text;
                // 如果需要，在这里添加验证逻辑
            }
        }
    }
}