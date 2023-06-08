using LV_CATEGORISATION.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Sylvan.Data;
using Sylvan.Data.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace LV_CATEGORISATION
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        readonly LvCategorisationContext _context;

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
        public string ResultsFileFullPath
        {
            get { return _resultsFileName; }
            set 
            { 
                _resultsFileName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultsFileFullPath)));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _context = new();
        }

        private void LOADButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    // Display selected file in UI
                    ResultsFileFullPath = openFileDialog.FileName;

                    // Read in results from .xlsx file
                    ExcelDataReader edr = ExcelDataReader.Create(ResultsFileFullPath);

                    //} while (edr.NextResult());
                    var Records = edr.GetRecords<InputResult>();
                    ListOfInputResults = new(edr.GetRecords<InputResult>());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //throw exc;
            }
        }

        private void TODBButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListOfInputResults.IsNullOrEmpty())
            {
                MessageBox.Show("Please load a results file first.");
                return;
            }

            foreach (InputResult item in ListOfInputResults)
            {
                if (item == ListOfInputResults.First())
                {
                    MessageBox.Show("First item successfully transfered to database. Please wait.");
                }

                Result tempResult = TransferProperties(new Result(), item);
                _context.Add(tempResult);
                _context.SaveChanges();

                if (item == ListOfInputResults.Last())
                {
                    MessageBox.Show("Last item successfully transfered to database.");
                }
            }
            
        }

        private Result TransferProperties(Result toFill, InputResult origin)
        {
            //toFill.Id = origin.Id;
            toFill.Positionsnummer = origin.Positionsnummer;
            toFill.Kurztext = origin.Kurztext;
            toFill.Menge = origin.Menge;
            toFill.Einheiten = origin.Einheiten;
            toFill.Langtext = origin.Langtext;
            toFill.Lokale = origin.Lokale;
            toFill.Filter = origin.Filter;
            toFill.Beschreibung = origin.Beschreibung;
            toFill.WeitereBemerkungen = origin.WeitereBemerkungen;
            toFill.Treffer = origin.Treffer;

            return toFill;
        }

        private void EXITButtonClicked(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
