using LV_CATEGORISATION.Entities;
using Microsoft.Win32;
using Sylvan.Data;
using Sylvan.Data.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;



namespace LV_CATEGORISATION
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<InputResult> _listOfInputResults;

        public List<InputResult> ListOfInputResults
        {
            get { return _listOfInputResults; }
            set 
            { 
                _listOfInputResults = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOfInputResults)));
            }
        }


        private string _resultsFileName;
        public string ResultsFilePath
        {
            get { return _resultsFileName; }
            set 
            { 
                _resultsFileName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultsFilePath)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BU01ButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    // Display selected file in UI
                    ResultsFilePath = openFileDialog.FileName;
                    // string ResultsFileName = System.IO.Path.GetFileName(ResultsFilePath);

                    // Read in results from .xlsx file
                    ExcelDataReader edr = ExcelDataReader.Create(ResultsFilePath);

                    //do
                    //{
                    //    var sheetname = edr.WorksheetName;
                    //    // enumerate rows in current sheet

                    //    while (edr.Read())
                    //    {
                    //        // iterate cells in row
                    //        for (int i = 0; i < edr.FieldCount; i++)
                    //        {
                    //            var value = edr.GetString(i);
                    //        }

                    //    }

                    //} while (edr.NextResult());
                    var Records = edr.GetRecords<InputResult>();
                    ListOfInputResults = new(edr.GetRecords<InputResult>());

                    foreach (InputResult item in Records)
                    {
                        //Console.WriteLine($"{item.Positionsnummer}");
                        
                    }
                    
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //throw exc;
            }



}
    }
}
