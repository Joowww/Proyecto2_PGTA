using AstDecoder;
using System.Data;
using System.Reflection;

namespace Simulation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            {
                ApplicationConfiguration.Initialize();

                // Crear una instancia de Welcome
                Welcome welcome = new Welcome();
                Application.Run(welcome);

            }
        }
    }
}