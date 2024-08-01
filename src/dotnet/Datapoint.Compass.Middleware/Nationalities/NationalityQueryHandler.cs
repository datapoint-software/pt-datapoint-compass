using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Nationalities
{
    public sealed class NationalityQueryHandler : IQueryHandler<NationalityQuery, IEnumerable<Nationality>>
    {
        private static readonly Dictionary<string, Dictionary<string, string>> Messages = new()
        {
            {
                "pt",  new()
                {
                    { "AF", "Afeganistão" },
                    { "ZA", "África do Sul" },
                    { "AX", "Ilhas Åland" },
                    { "AL", "Albânia" },
                    { "DE", "Alemanha" },
                    { "AD", "Andorra" },
                    { "AO", "Angola" },
                    { "AI", "Anguila" },
                    { "AQ", "Antártida" },
                    { "AG", "Antígua e Barbuda" },
                    { "SA", "Arábia Saudita" },
                    { "DZ", "Argélia" },
                    { "AR", "Argentina" },
                    { "AM", "Armênia" },
                    { "AW", "Aruba" },
                    { "AU", "Austrália" },
                    { "AT", "Áustria" },
                    { "AZ", "Azerbaijão" },
                    { "BS", "Bahamas" },
                    { "BD", "Bangladexe" },
                    { "BB", "Barbados" },
                    { "BH", "Barém" },
                    { "BE", "Bélgica" },
                    { "BZ", "Belize" },
                    { "BJ", "Benim" },
                    { "BM", "Bermudas" },
                    { "BY", "Bielorrússia" },
                    { "BO", "Bolívia" },
                    { "BQ", "Países Baixos Caribenhos" },
                    { "BA", "Bósnia e Herzegovina" },
                    { "BW", "Botsuana" },
                    { "BV", "Ilha Bouvet" },
                    { "BR", "Brasil" },
                    { "BN", "Brunei" },
                    { "BG", "Bulgária" },
                    { "BF", "Burquina Fasso" },
                    { "BI", "Burundi" },
                    { "BT", "Butão" },
                    { "CV", "Cabo Verde" },
                    { "KY", "Ilhas Caimã" },
                    { "KH", "Camboja" },
                    { "CM", "Camarões" },
                    { "CA", "Canadá" },
                    { "QA", "Catar" },
                    { "KZ", "Cazaquistão" },
                    { "CF", "República Centro-Africana" },
                    { "TD", "Chade" },
                    { "CZ", "Chéquia" },
                    { "CL", "Chile" },
                    { "CN", "China" },
                    { "CY", "Chipre" },
                    { "CC", "Ilhas Cocos (Keeling)" },
                    { "CO", "Colômbia" },
                    { "KM", "Comores" },
                    { "CG", "República do Congo" },
                    { "CD", "República Democrática do Congo" },
                    { "CK", "Ilhas Cook" },
                    { "KR", "Coreia do Sul" },
                    { "KP", "Coreia do Norte" },
                    { "CI", "Costa do Marfim" },
                    { "CR", "Costa Rica" },
                    { "HR", "Croácia" },
                    { "CU", "Cuba" },
                    { "CW", "Curaçau" },
                    { "DK", "Dinamarca" },
                    { "DJ", "Djibuti" },
                    { "DM", "Dominica" },
                    { "DO", "República Dominicana" },
                    { "EG", "Egito" },
                    { "SV", "El Salvador" },
                    { "AE", "Emirados Árabes Unidos" },
                    { "EC", "Equador" },
                    { "ER", "Eritreia" },
                    { "SK", "Eslováquia" },
                    { "SI", "Eslovênia" },
                    { "ES", "Espanha" },
                    { "US", "Estados Unidos" },
                    { "EE", "Estónia" },
                    { "SZ", "Essuatíni" },
                    { "SJ", "Esvalbarde e Jan Mayen" },
                    { "ET", "Etiópia" },
                    { "FO", "Ilhas Feroé" },
                    { "FJ", "Fiji" },
                    { "PH", "Filipinas" },
                    { "FI", "Finlândia" },
                    { "FR", "França" },
                    { "GA", "Gabão" },
                    { "GM", "Gâmbia" },
                    { "GH", "Gana" },
                    { "GE", "Geórgia" },
                    { "GS", "Ilhas Geórgia do Sul e Sandwich do Sul" },
                    { "GI", "Gibraltar" },
                    { "GD", "Granada" },
                    { "GR", "Grécia" },
                    { "GL", "Gronelândia" },
                    { "GP", "Guadalupe" },
                    { "GU", "Guam" },
                    { "GT", "Guatemala" },
                    { "GG", "Guernsey" },
                    { "GY", "Guiana" },
                    { "GF", "Guiana Francesa" },
                    { "GW", "Guiné-Bissau" },
                    { "GN", "Guiné" },
                    { "GQ", "Guiné Equatorial" },
                    { "HT", "Haiti" },
                    { "HM", "Ilha Heard e Ilhas McDonald" },
                    { "HN", "Honduras" },
                    { "HK", "Hong Kong" },
                    { "HU", "Hungria" },
                    { "YE", "Iêmen" },
                    { "IN", "Índia" },
                    { "ID", "Indonésia" },
                    { "IQ", "Iraque" },
                    { "IR", "Irã" },
                    { "IE", "Irlanda" },
                    { "IS", "Islândia" },
                    { "IL", "Israel" },
                    { "IT", "Itália" },
                    { "JM", "Jamaica" },
                    { "JP", "Japão" },
                    { "JE", "Jersey" },
                    { "JO", "Jordânia" },
                    { "KW", "Kuwait" },
                    { "LA", "Laos" },
                    { "LS", "Lesoto" },
                    { "LV", "Letônia" },
                    { "LB", "Líbano" },
                    { "LR", "Libéria" },
                    { "LY", "Líbia" },
                    { "LI", "Listenstaine" },
                    { "LT", "Lituânia" },
                    { "LU", "Luxemburgo" },
                    { "MO", "Macau" },
                    { "MK", "Macedônia do Norte" },
                    { "MG", "Madagáscar" },
                    { "YT", "Maiote" },
                    { "MY", "Malásia" },
                    { "MW", "Maláui" },
                    { "MV", "Maldivas" },
                    { "ML", "Mali" },
                    { "MT", "Malta" },
                    { "FK", "Ilhas Malvinas" },
                    { "IM", "Ilha de Man" },
                    { "MP", "Marianas Setentrionais" },
                    { "MA", "Marrocos" },
                    { "MH", "Ilhas Marshall" },
                    { "MQ", "Martinica" },
                    { "MU", "Ilhas Maurícias" },
                    { "MR", "Mauritânia" },
                    { "UM", "Ilhas Menores Distantes dos Estados Unidos" },
                    { "MX", "México" },
                    { "MM", "Mianmar" },
                    { "FM", "Estados Federados da Micronésia" },
                    { "MZ", "Moçambique" },
                    { "MD", "Moldávia" },
                    { "MC", "Mónaco" },
                    { "MN", "Mongólia" },
                    { "MS", "Monserrate" },
                    { "ME", "Montenegro" },
                    { "NA", "Namíbia" },
                    { "CX", "Ilha do Natal" },
                    { "NR", "Nauru" },
                    { "NP", "Nepal" },
                    { "NI", "Nicarágua" },
                    { "NE", "Níger" },
                    { "NG", "Nigéria" },
                    { "NU", "Niue" },
                    { "NF", "Ilha Norfolk" },
                    { "NO", "Noruega" },
                    { "NC", "Nova Caledônia" },
                    { "NZ", "Nova Zelândia" },
                    { "OM", "Omã" },
                    { "NL", "Países Baixos" },
                    { "PW", "Palau" },
                    { "PS", "Palestina" },
                    { "PA", "Panamá" },
                    { "PG", "Papua-Nova Guiné" },
                    { "PK", "Paquistão" },
                    { "PY", "Paraguai" },
                    { "PE", "Peru" },
                    { "PN", "Pitcairn" },
                    { "PF", "Polinésia Francesa" },
                    { "PL", "Polónia" },
                    { "PR", "Porto Rico" },
                    { "PT", "Portuguesa" },
                    { "KE", "Quênia" },
                    { "KG", "Quirguistão" },
                    { "KI", "Quiribáti" },
                    { "GB", "Reino Unido" },
                    { "RE", "Reunião" },
                    { "RO", "Roménia" },
                    { "RW", "Ruanda" },
                    { "RU", "Rússia" },
                    { "EH", "Saara Ocidental" },
                    { "AS", "Samoa Americana" },
                    { "WS", "Samoa" },
                    { "SB", "Ilhas Salomão" },
                    { "SM", "San Marino" },
                    { "SH", "Santa Helena, Ascensão e Tristão da Cunha" },
                    { "LC", "Santa Lúcia" },
                    { "BL", "São Bartolomeu" },
                    { "KN", "São Cristóvão e Neves" },
                    { "MF", "São Martinho" },
                    { "SX", "São Martinho" },
                    { "PM", "São Pedro e Miquelão" },
                    { "ST", "São Tomé e Príncipe" },
                    { "VC", "São Vicente e Granadinas" },
                    { "SC", "Seicheles" },
                    { "SN", "Senegal" },
                    { "LK", "Seri Lanca" },
                    { "SL", "Serra Leoa" },
                    { "RS", "Sérvia" },
                    { "SG", "Singapura" },
                    { "SY", "Síria" },
                    { "SO", "Somália" },
                    { "SD", "Sudão" },
                    { "SS", "Sudão do Sul" },
                    { "SE", "Suécia" },
                    { "CH", "Suíça" },
                    { "SR", "Suriname" },
                    { "TH", "Tailândia" },
                    { "TW", "Taiwan" },
                    { "TJ", "Tajiquistão" },
                    { "TZ", "Tanzânia" },
                    { "TF", "Terras Austrais e Antárticas Francesas" },
                    { "IO", "Território Britânico do Oceano Índico" },
                    { "TL", "Timor-Leste" },
                    { "TG", "Togo" },
                    { "TO", "Tonga" },
                    { "TK", "Toquelau" },
                    { "TT", "Trinidad e Tobago" },
                    { "TN", "Tunísia" },
                    { "TC", "Turcas e Caicos" },
                    { "TM", "Turcomenistão" },
                    { "TR", "Turquia" },
                    { "TV", "Tuvalu" },
                    { "UA", "Ucrânia" },
                    { "UG", "Uganda" },
                    { "UY", "Uruguai" },
                    { "UZ", "Uzbequistão" },
                    { "VU", "Vanuatu" },
                    { "VA", "Vaticano" },
                    { "VE", "Venezuela" },
                    { "VN", "Vietname" },
                    { "VI", "Ilhas Virgens Americanas" },
                    { "VG", "Ilhas Virgens Britânicas" },
                    { "WF", "Wallis e Futuna" },
                    { "ZM", "Zâmbia" },
                    { "ZW", "Zimbábue" }
                }
            }
        };

        private readonly IMemoryCache _memoryCache;

        private readonly CompassContext _compass;

        public NationalityQueryHandler(IMemoryCache memoryCache, CompassContext compass)
        {
            _memoryCache = memoryCache;
            _compass = compass;
        }

        public Task<IEnumerable<Nationality>> HandleQueryAsync(NationalityQuery query, CancellationToken ct)
        {
            var language = query.Locale switch
            {
                Locale.Portuguese => "pt",
                _ => "en"
            };

            Messages.TryGetValue(language, out var messages);

            return _memoryCache.GetOrCreateAsync($"nationalities/{language}", async (_) =>
            {
                var countries = await _compass.Countries
                    .AsNoTracking()
                    .Select(c => new { c.Code, c.Nationality })
                    .ToListAsync(ct);

                return countries
                    .Select((country) => new Nationality(
                        country.Code,
                        (messages?.TryGetValue(country.Code, out var translation) ?? false)
                            ? translation
                            : country.Nationality))
                    .OrderBy(n => n.Name)
                    .AsEnumerable();
            })!;
        }
    }
}
