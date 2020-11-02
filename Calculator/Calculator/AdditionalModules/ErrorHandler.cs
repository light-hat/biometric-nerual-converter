using System.Windows.Forms;

namespace Calculator.AdditionalModules
{
    /// <summary>
    /// Обработка ошибок
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// Показать сообщение об ошибке
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void showMessage(string message)
        {
            MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
