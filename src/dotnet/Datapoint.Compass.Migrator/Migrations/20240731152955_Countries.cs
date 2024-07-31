using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Countries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    CodeA3 = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    CodeN3 = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Nationality = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                    table.UniqueConstraint("AK_Countries_CodeA3", x => x.CodeA3);
                    table.UniqueConstraint("AK_Countries_CodeN3", x => x.CodeN3);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AF", "AFG", "004", "Afghanistan", "Afghan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AX", "ALA", "248", "Åland Islands", "Åland Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AL", "ALB", "008", "Albania", "Albanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["DZ", "DZA", "012", "Algeria", "Algerian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AS", "ASM", "016", "American Samoa", "American Samoan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AD", "AND", "020", "Andorra", "Andorran"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AO", "AGO", "024", "Angola", "Angolan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AI", "AIA", "660", "Anguilla", "Anguillan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AQ", "ATA", "010", "Antarctica", "Antarctic"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AG", "ATG", "028", "Antigua and Barbuda", "Antiguan or Barbudan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AR", "ARG", "032", "Argentina", "Argentine"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AM", "ARM", "051", "Armenia", "Armenian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AW", "ABW", "533", "Aruba", "Aruban"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AU", "AUS", "036", "Australia", "Australian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AT", "AUT", "040", "Austria", "Austrian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AZ", "AZE", "031", "Azerbaijan", "Azerbaijani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BS", "BHS", "044", "Bahamas", "Bahamian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BH", "BHR", "048", "Bahrain", "Bahraini"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BD", "BGD", "050", "Bangladesh", "Bangladeshi"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BB", "BRB", "052", "Barbados", "Barbadian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BY", "BLR", "112", "Belarus", "Belarusian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BE", "BEL", "056", "Belgium", "Belgian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BZ", "BLZ", "084", "Belize", "Belizean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BJ", "BEN", "204", "Benin", "Beninese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BM", "BMU", "060", "Bermuda", "Bermudian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BT", "BTN", "064", "Bhutan", "Bhutanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BO", "BOL", "068", "Bolivia", "Bolivian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BQ", "BES", "535", "Bonaire", "Bonaire"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BA", "BIH", "070", "Bosnia and Herzegovina", "Bosnian or Herzegovinian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BW", "BWA", "072", "Botswana", "Motswana"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BV", "BVT", "074", "Bouvet Island", "Bouvet Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BR", "BRA", "076", "Brazil", "Brazilian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IO", "IOT", "086", "British Indian Ocean Territory", "BIOT"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BN", "BRN", "096", "Brunei Darussalam", "Bruneian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BG", "BGR", "100", "Bulgaria", "Bulgarian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BF", "BFA", "854", "Burkina Faso", "Burkinabé"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BI", "BDI", "108", "Burundi", "Burundian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CV", "CPV", "132", "Cabo Verde", "Cabo Verdean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KH", "KHM", "116", "Cambodia", "Cambodian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CM", "CMR", "120", "Cameroon", "Cameroonian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CA", "CAN", "124", "Canada", "Canadian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KY", "CYM", "136", "Cayman Islands", "Caymanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CF", "CAF", "140", "Central African Republic", "Central African"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TD", "TCD", "148", "Chad", "Chadian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CL", "CHL", "152", "Chile", "Chilean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CN", "CHN", "156", "China", "Chinese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CX", "CXR", "162", "Christmas Island", "Christmas Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CC", "CCK", "166", "Cocos (Keeling) Islands", "Cocos Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CO", "COL", "170", "Colombia", "Colombian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KM", "COM", "174", "Comoros", "Comoran"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CG", "COG", "178", "Republic of the Congo", "Congolese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CD", "COD", "180", "Democratic Republic of the Congo", "Congolese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CK", "COK", "184", "Cook Islands", "Cook Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CR", "CRI", "188", "Costa Rica", "Costa Rican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CI", "CIV", "384", "Côte d'Ivoire", "Ivorian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["HR", "HRV", "191", "Croatia", "Croatian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CU", "CUB", "192", "Cuba", "Cuban"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CW", "CUW", "531", "Curaçao", "Curaçaoan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CY", "CYP", "196", "Cyprus", "Cypriot"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CZ", "CZE", "203", "Czech Republic", "Czech"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["DK", "DNK", "208", "Denmark", "Danish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["DJ", "DJI", "262", "Djibouti", "Djiboutian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["DM", "DMA", "212", "Dominica", "Dominican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["DO", "DOM", "214", "Dominican Republic", "Dominican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["EC", "ECU", "218", "Ecuador", "Ecuadorian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["EG", "EGY", "818", "Egypt", "Egyptian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SV", "SLV", "222", "El Salvador", "Salvadoran"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GQ", "GNQ", "226", "Equatorial Guinea", "Equatorial Guinean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ER", "ERI", "232", "Eritrea", "Eritrean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["EE", "EST", "233", "Estonia", "Estonian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ET", "ETH", "231", "Ethiopia", "Ethiopian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["FK", "FLK", "238", "Falkland Islands", "Falkland Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["FO", "FRO", "234", "Faroe Islands", "Faroese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["FJ", "FJI", "242", "Fiji", "Fijian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["FI", "FIN", "246", "Finland", "Finnish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["FR", "FRA", "250", "France", "French"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GF", "GUF", "254", "French Guiana", "French Guianese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PF", "PYF", "258", "French Polynesia", "French Polynesian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TF", "ATF", "260", "French Southern Territories", "French Southern Territories"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GA", "GAB", "266", "Gabon", "Gabonese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GM", "GMB", "270", "Gambia", "Gambian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GE", "GEO", "268", "Georgia", "Georgian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["DE", "DEU", "276", "Germany", "German"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GH", "GHA", "288", "Ghana", "Ghanaian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GI", "GIB", "292", "Gibraltar", "Gibraltar"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GR", "GRC", "300", "Greece", "Greek"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GL", "GRL", "304", "Greenland", "Greenlandic"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GD", "GRD", "308", "Grenada", "Grenadian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GP", "GLP", "312", "Guadeloupe", "Guadeloupe"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GU", "GUM", "316", "Guam", "Guamanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GT", "GTM", "320", "Guatemala", "Guatemalan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GG", "GGY", "831", "Guernsey", "Channel Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GN", "GIN", "324", "Guinea", "Guinean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GW", "GNB", "624", "Guinea-Bissau", "Bissau-Guinean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GY", "GUY", "328", "Guyana", "Guyanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["HT", "HTI", "332", "Haiti", "Haitian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["HM", "HMD", "334", "Heard Island and McDonald Islands", "Heard Island or McDonald Islands"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VA", "VAT", "336", "Vatican City State", "Vatican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["HN", "HND", "340", "Honduras", "Honduran"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["HK", "HKG", "344", "Hong Kong", "Hong Kong"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["HU", "HUN", "348", "Hungary", "Hungarian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IS", "ISL", "352", "Iceland", "Icelandic"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IN", "IND", "356", "India", "Indian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ID", "IDN", "360", "Indonesia", "Indonesian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IR", "IRN", "364", "Iran", "Iranian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IQ", "IRQ", "368", "Iraq", "Iraqi"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IE", "IRL", "372", "Ireland", "Irish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IM", "IMN", "833", "Isle of Man", "Manx"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IL", "ISR", "376", "Israel", "Israeli"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["IT", "ITA", "380", "Italy", "Italian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["JM", "JAM", "388", "Jamaica", "Jamaican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["JP", "JPN", "392", "Japan", "Japanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["JE", "JEY", "832", "Jersey", "Channel Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["JO", "JOR", "400", "Jordan", "Jordanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KZ", "KAZ", "398", "Kazakhstan", "Kazakhstani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KE", "KEN", "404", "Kenya", "Kenyan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KI", "KIR", "296", "Kiribati", "I-Kiribati"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KP", "PRK", "408", "Democratic People's Republic of Korea", "North Korean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KR", "KOR", "410", "Republic of Korea", "South Korean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KW", "KWT", "414", "Kuwait", "Kuwaiti"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KG", "KGZ", "417", "Kyrgyzstan", "Kyrgyzstani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LA", "LAO", "418", "Lao People's Democratic Republic", "Lao"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LV", "LVA", "428", "Latvia", "Latvian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LB", "LBN", "422", "Lebanon", "Lebanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LS", "LSO", "426", "Lesotho", "Basotho"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LR", "LBR", "430", "Liberia", "Liberian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LY", "LBY", "434", "Libya", "Libyan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LI", "LIE", "438", "Liechtenstein", "Liechtenstein"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LT", "LTU", "440", "Lithuania", "Lithuanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LU", "LUX", "442", "Luxembourg", "Luxembourg"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MO", "MAC", "446", "Macao", "Macanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MK", "MKD", "807", "Macedonia", "Macedonian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MG", "MDG", "450", "Madagascar", "Malagasy"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MW", "MWI", "454", "Malawi", "Malawian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MY", "MYS", "458", "Malaysia", "Malaysian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MV", "MDV", "462", "Maldives", "Maldivian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ML", "MLI", "466", "Mali", "Malian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MT", "MLT", "470", "Malta", "Maltese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MH", "MHL", "584", "Marshall Islands", "Marshallese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MQ", "MTQ", "474", "Martinique", "Martiniquais"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MR", "MRT", "478", "Mauritania", "Mauritanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MU", "MUS", "480", "Mauritius", "Mauritian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["YT", "MYT", "175", "Mayotte", "Mahoran"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MX", "MEX", "484", "Mexico", "Mexican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["FM", "FSM", "583", "Micronesia", "Micronesian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MD", "MDA", "498", "Moldova", "Moldovan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MC", "MCO", "492", "Monaco", "Monégasque"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MN", "MNG", "496", "Mongolia", "Mongolian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ME", "MNE", "499", "Montenegro", "Montenegrin"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MS", "MSR", "500", "Montserrat", "Montserratian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MA", "MAR", "504", "Morocco", "Moroccan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MZ", "MOZ", "508", "Mozambique", "Mozambican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MM", "MMR", "104", "Myanmar", "Burmese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NA", "NAM", "516", "Namibia", "Namibian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NR", "NRU", "520", "Nauru", "Nauruan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NP", "NPL", "524", "Nepal", "Nepali"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NL", "NLD", "528", "Netherlands", "Dutch"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NC", "NCL", "540", "New Caledonia", "New Caledonian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NZ", "NZL", "554", "New Zealand", "New Zealand"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NI", "NIC", "558", "Nicaragua", "Nicaraguan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NE", "NER", "562", "Niger", "Nigerien"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NG", "NGA", "566", "Nigeria", "Nigerian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NU", "NIU", "570", "Niue", "Niuean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NF", "NFK", "574", "Norfolk Island", "Norfolk Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MP", "MNP", "580", "Northern Mariana Islands", "Northern Marianan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["NO", "NOR", "578", "Norway", "Norwegian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["OM", "OMN", "512", "Oman", "Omani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PK", "PAK", "586", "Pakistan", "Pakistani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PW", "PLW", "585", "Palau", "Palauan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PS", "PSE", "275", "Palestine", "Palestinian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PA", "PAN", "591", "Panama", "Panamanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PG", "PNG", "598", "Papua New Guinea", "Papua New Guinean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PY", "PRY", "600", "Paraguay", "Paraguayan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PE", "PER", "604", "Peru", "Peruvian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PH", "PHL", "608", "Philippines", "Philippine"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PN", "PCN", "612", "Pitcairn", "Pitcairn Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PL", "POL", "616", "Poland", "Polish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PT", "PRT", "620", "Portugal", "Portuguese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PR", "PRI", "630", "Puerto Rico", "Puerto Rican"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["QA", "QAT", "634", "Qatar", "Qatari"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["RE", "REU", "638", "Réunion", "Réunionese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["RO", "ROU", "642", "Romania", "Romanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["RU", "RUS", "643", "Russian Federation", "Russian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["RW", "RWA", "646", "Rwanda", "Rwandan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["BL", "BLM", "652", "Saint Barthélemy", "Barthélemois"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SH", "SHN", "654", "Saint Helena", "Saint Helenian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["KN", "KNA", "659", "Saint Kitts and Nevis", "Kittitian or Nevisian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LC", "LCA", "662", "Saint Lucia", "Saint Lucian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["MF", "MAF", "663", "Saint Martin", "Saint-Martinoise"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["PM", "SPM", "666", "Saint Pierre and Miquelon", "Saint-Pierrais or Miquelonnais"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VC", "VCT", "670", "Saint Vincent and the Grenadines", "Saint Vincentian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["WS", "WSM", "882", "Samoa", "Samoan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SM", "SMR", "674", "San Marino", "Sammarinese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ST", "STP", "678", "Sao Tome and Principe", "São Toméan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SA", "SAU", "682", "Saudi Arabia", "Saudi"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SN", "SEN", "686", "Senegal", "Senegalese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["RS", "SRB", "688", "Serbia", "Serbian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SC", "SYC", "690", "Seychelles", "Seychellois"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SL", "SLE", "694", "Sierra Leone", "Sierra Leonean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SG", "SGP", "702", "Singapore", "Singaporean"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SX", "SXM", "534", "Sint Maarten", "Sint Maarten"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SK", "SVK", "703", "Slovakia", "Slovak"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SI", "SVN", "705", "Slovenia", "Slovenian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SB", "SLB", "090", "Solomon Islands", "Solomon Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SO", "SOM", "706", "Somalia", "Somali"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ZA", "ZAF", "710", "South Africa", "South African"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GS", "SGS", "239", "South Georgia and the South Sandwich Islands", "South Georgia or South Sandwich Islands"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SS", "SSD", "728", "South Sudan", "South Sudanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ES", "ESP", "724", "Spain", "Spanish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["LK", "LKA", "144", "Sri Lanka", "Sri Lankan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SD", "SDN", "729", "Sudan", "Sudanese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SR", "SUR", "740", "Suriname", "Surinamese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SJ", "SJM", "744", "Svalbard and Jan Mayen", "Svalbard"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SZ", "SWZ", "748", "Swaziland", "Swazi"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SE", "SWE", "752", "Sweden", "Swedish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["CH", "CHE", "756", "Switzerland", "Swiss"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["SY", "SYR", "760", "Syrian Arab Republic", "Syrian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TW", "TWN", "158", "Taiwan", "Chinese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TJ", "TJK", "762", "Tajikistan", "Tajikistani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TZ", "TZA", "834", "Tanzania", "Tanzanian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TH", "THA", "764", "Thailand", "Thai"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TL", "TLS", "626", "Timor-Leste", "Timorese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TG", "TGO", "768", "Togo", "Togolese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TK", "TKL", "772", "Tokelau", "Tokelauan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TO", "TON", "776", "Tonga", "Tongan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TT", "TTO", "780", "Trinidad and Tobago", "Trinidadian or Tobagonian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TN", "TUN", "788", "Tunisia", "Tunisian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TR", "TUR", "792", "Turkey", "Turkish"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TM", "TKM", "795", "Turkmenistan", "Turkmen"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TC", "TCA", "796", "Turks and Caicos Islands", "Turks and Caicos Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["TV", "TUV", "798", "Tuvalu", "Tuvaluan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["UG", "UGA", "800", "Uganda", "Ugandan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["UA", "UKR", "804", "Ukraine", "Ukrainian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["AE", "ARE", "784", "United Arab Emirates", "Emirati"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["GB", "GBR", "826", "United Kingdom of Great Britain and Northern Ireland", "British"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["UM", "UMI", "581", "United States Minor Outlying Islands", "American"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["US", "USA", "840", "United States of America", "American"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["UY", "URY", "858", "Uruguay", "Uruguayan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["UZ", "UZB", "860", "Uzbekistan", "Uzbekistani"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VU", "VUT", "548", "Vanuatu", "Ni-Vanuatu"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VE", "VEN", "862", "Venezuela", "Venezuelan"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VN", "VNM", "704", "Vietnam", "Vietnamese"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VG", "VGB", "092", "British Virgin Islands", "British Virgin Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["VI", "VIR", "850", "U.S. Virgin Islands", "U.S. Virgin Island"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["WF", "WLF", "876", "Wallis and Futuna", "Wallis and Futuna"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["EH", "ESH", "732", "Western Sahara", "Sahrawi"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["YE", "YEM", "887", "Yemen", "Yemeni"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ZM", "ZMB", "894", "Zambia", "Zambian"]);
            migrationBuilder.InsertData("Countries", ["Code", "CodeA3", "CodeN3", "Name", "Nationality"], ["ZW", "ZWE", "716", "Zimbabwe", "Zimbabwean"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
