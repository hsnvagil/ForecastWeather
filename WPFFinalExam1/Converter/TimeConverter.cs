namespace WPFFinalExam1.Converter {
    public class TimeConverter {
        public string ConvertHour(string time) {
            switch (time) {
                case "0":
                    return "12 am";
                case "100":
                    return "1 am";
                case "200":
                    return "2 am";
                case "300":
                    return "3 am";
                case "400":
                    return "4 am";
                case "500":
                    return "5 am";
                case "600":
                    return "6 am";
                case "700":
                    return "7 am";
                case "800":
                    return "8 am";
                case "900":
                    return "9 am";
                case "1000":
                    return "10 am";
                case "1100":
                    return "11 am";

                case "1200":
                    return "12 pm";
                case "1300":
                    return "1 pm";
                case "1400":
                    return "2 pm";
                case "1500":
                    return "3 pm";
                case "1600":
                    return "4 pm";
                case "1700":
                    return "5 pm";
                case "1800":
                    return "6 pm";
                case "1900":
                    return "7 pm";
                case "2000":
                    return "8 pm";
                case "2100":
                    return "9 pm";
                case "2200":
                    return "10 pm";
                case "2300":
                    return "11 pm";
                default:
                    return null;
            }
        }
    }
}