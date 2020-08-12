namespace WPFFinalExam1.Converter {
    internal class IconConvert {
        public string ConverterIcon(string icon) {
            switch (icon) {
                case "t01d":
                case "t02d":
                case "t03d":
                case "t04d":
                case "t05d":
                    return "11d";
                case "t01n":
                case "t02n":
                case "t03n":
                case "t04n":
                case "t05n":
                    return "11n";
                case "d01d":
                case "d02d":
                case "d03d":
                case "d01n":
                case "d02n":
                case "d03n":
                    return "09d";
                case "r01d":
                case "r02d":
                case "r03d":
                case "r05d":
                case "r06d":
                case "r04d":
                case "f01d":
                    return "10d";
                case "r01n":
                case "r02n":
                case "r03n":
                case "r04n":
                case "r05n":
                case "r06n":
                case "f01n":
                    return "10n";
                case "s01d":
                case "s02d":
                case "s03d":
                case "s04d":
                case "s05d":
                case "s06d":
                    return "13d";
                case "s01n":
                case "s02n":
                case "s03n":
                case "s04n":
                case "s05n":
                case "s06n":
                    return "13n";
                case "a01d":
                case "a02d":
                case "a03d":
                case "a04d":
                case "a05d":
                case "a06d":
                case "a01n":
                case "a02n":
                case "a03n":
                case "a04n":
                case "a05n":
                case "a06n":
                    return "50d";
                case "c01d":
                    return "01d";
                case "c01n":
                    return "01n";
                case "c02d":
                    return "02d";
                case "c02n":
                    return "02n";
                case "c03d":
                case "c03n":
                    return "03d";
                case "c04d":
                case "c04n":
                    return "04d";
                default:
                    return null;
            }
        }
    }
}