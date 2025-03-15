namespace TasklyApp.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class AlternatingColorConverter : IMultiValueConverter
    {
        private static readonly SolidColorBrush DefaultColor = new SolidColorBrush(Color.FromRgb(28, 141, 254)); // Blue #1C8DFE
        private static readonly SolidColorBrush[] Colors =
        {
            new SolidColorBrush(Color.FromRgb(28, 141, 254)), // Blue
            new SolidColorBrush(Color.FromRgb(55, 202, 38)),  // Green
            new SolidColorBrush(Color.FromRgb(254, 50, 28)),  // Red
            new SolidColorBrush(Color.FromRgb(152, 67, 202))  // Purple
        };

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] is not System.Collections.IEnumerable items || values[1] == null)
                return DefaultColor;

            int index = 0;
            foreach (var item in items)
            {
                if (item == values[1])
                    break;
                index++;
            }

            return Colors[index % Colors.Length]; // Cycle through colors
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
