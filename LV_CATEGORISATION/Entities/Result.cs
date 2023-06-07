using System;
using System.Collections.Generic;

namespace LV_CATEGORISATION.Entities;

public partial class Result
{
    public int Id { get; set; }

    public string Positionsnummer { get; set; }

    public string Kurztext { get; set; }

    public decimal? Menge { get; set; }

    public string Einheiten { get; set; }

    public string Langtext { get; set; }

    public string Lokale { get; set; }

    public string Filter { get; set; }

    public string Beschreibung { get; set; }

    public string WeitereBemerkungen { get; set; }

    public string Treffer { get; set; }
}
