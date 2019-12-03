using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _14_CRUD_PersonasUWP_UI.ViewModels.Utiles
{
    public class clsConversorFechaDatePicker : IValueConverter
    {
        /// <summary>
        /// Este metodo convierte la fecha del datepicker de datetime a datetimeoffset
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>Devuelve un datetimeoffset</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = (DateTime)value;

            //Para evitar que pete por tener el año como 1919
            if (fecha.Year < 1919)
            {
                fecha = new DateTime(1919, fecha.Month, fecha.Day);
            }

            DateTimeOffset fechaDevuelta = new DateTimeOffset(fecha);

            return fechaDevuelta;
        }


        /// <summary>
        /// Este metodo convierte la fecha del datepicker de datetimeoffset a datetime
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>Devuelve un datetime</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset fechaOffSet = (DateTimeOffset)value;
            DateTime fecha = fechaOffSet.DateTime;

            return fecha;
        }
    }
}
