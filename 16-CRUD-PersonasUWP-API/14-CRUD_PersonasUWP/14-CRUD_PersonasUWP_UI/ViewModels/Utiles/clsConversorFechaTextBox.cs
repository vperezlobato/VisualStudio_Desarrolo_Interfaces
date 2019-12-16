using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _14_CRUD_PersonasUWP_UI.ViewModels.Utiles
{
    public class clsConversorFechaTextBox :IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = (DateTime)value;
          
            return fecha.ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            String fecha = (String)value;
            DateTime fechaValidada = new DateTime();

            if (DateTime.TryParse(fecha,out fechaValidada)) {
                fechaValidada = DateTime.Parse(fecha);
            }

            return fechaValidada; 
        }
    }
}
