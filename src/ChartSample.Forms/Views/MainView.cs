using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartSample.Forms.BindHelpers;
using CommandLine;
using WinFormsMvvmSample.Services;
using WinFormsMvvmSample.ViewModels;

namespace WinFormsMvvmSample.Views
{
    // コマンドラインオプション取得
    internal class Options
    {
        /// <summary>
        /// Businessモデル名を入力
        /// </summary>
        [Option('B', "BU", Required = true, HelpText = "BUを入力する")]
        public string Bu { get; set; }
    }

    public partial class MainView : Form
    {

        private readonly MainViewModel _viewModel;

        public MainView()
        {
            InitializeComponent();

            var options = GetOptions();

            _viewModel = new MainViewModel(new MessageService(), new MachineDataService()) {AaaTextBoxText = options.Bu};


            // Binding
            AAATextBox.DataBindings.Add(nameof(AAATextBox.Text), _viewModel, nameof(_viewModel.AaaTextBoxText));

            StartDatePicker.DataBindings.Add(nameof(StartDatePicker.Value), _viewModel,
                nameof(_viewModel.StartDateTimeValue));
            EndDatePicker.DataBindings.Add(nameof(EndDatePicker.Value), _viewModel,
                nameof(_viewModel.EndDateTimeValue));

            // DataGridの設定
            MachineDataGrid.DataSource = _viewModel.MachineDataGridSource;

            // ReSharper disable once PossibleNullReferenceException
            MachineDataGrid.Columns[nameof(MainViewModelGrid.Id)].HeaderText = @"機種番号";
            // ReSharper disable once PossibleNullReferenceException
            MachineDataGrid.Columns[nameof(MainViewModelGrid.Name)].HeaderText = @"機種名";

            // グラフ領域の設定
            var area = new ChartArea
            {
                AxisX =
                {
                    Title = "日付",
                    IntervalType = DateTimeIntervalType.Days,
                    Minimum = new DateTime(2010, 1, 1).ToOADate(),
                    Maximum = new DateTime(2010, 1, 10).ToOADate()
                },
                AxisY = {Title = "株価", Minimum = 950, Maximum = 1050}
            };

            // 横軸（日付軸）の設定 
            // DateTimeのままでは使えないので
            //ToOADateメソッドでOLEオートメーション日付に変換

            // 縦軸（株価軸）の設定

            // 既定のグラフ領域の設定をクリアした後、設定する
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(area);

            // データ系列を作成する
            var series = new Series {ChartType = SeriesChartType.Candlestick, Color = Color.Blue};

            for (var i = 0; i < 5; i++)
            {
                // 日付(2010/1/4から5本)
                var date = new DateTime(2010, 1, 4).AddDays(i);

                // High Low Open Closeの順番で配列を作成
                var values = new double[]
                {
                    1010 + i, 990 + i, 1000 + i, 1005 + i
                };

                // 日付、四本値の配列からDataPointのインスタンスを作成
                var dp = new DataPoint(date.ToOADate(), values);
                series.Points.Add(dp);
            }

            chart1.Series.Clear();
            chart1.Series.Add(series);

        }

        /// <summary>
        /// オプションを取得
        /// </summary>
        /// <returns></returns>
        private Options GetOptions()
        {
            var args = Environment.GetCommandLineArgs();

            var parserResult = Parser.Default.ParseArguments<Options>(args);

            if (parserResult.Tag != ParserResultType.Parsed) return null;
            if (!(parserResult is Parsed<Options> parsed)) return null;
            var opt = parsed.Value;

            return opt;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _viewModel.Update();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _viewModel.Save();
        }
    }
}