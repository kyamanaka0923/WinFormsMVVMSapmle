using System;
using System.Windows.Forms;
using CommandLine;
using WinFormsMvvmSample.Views;

namespace WinFormsMvvmSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var options = GetOptions();

            Application.Run(new MainView(options));
        }

        /// <summary>
        /// オプションを取得
        /// </summary>
        /// <returns></returns>
        private static Options GetOptions()
        {
            var args = Environment.GetCommandLineArgs();

            var parserResult = Parser.Default.ParseArguments<Options>(args);

            if (parserResult.Tag != ParserResultType.Parsed) return null;
            if (!(parserResult is Parsed<Options> parsed)) return null;
            var opt = parsed.Value;

            return opt;

        }

    }

    // コマンドラインオプション取得
    public class Options
    {
        /// <summary>
        /// Businessモデル名を入力
        /// </summary>
        [Option('B', "BU", Required = true, HelpText = "BUを入力する")]
        public string Bu { get; set; }
    }

}