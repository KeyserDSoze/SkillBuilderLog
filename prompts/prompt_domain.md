Quando crei delle classi di dominio utilizza sempre delle proprietà che sono nullable e non hanno
String.Empty come default e che abbiano un jsonpropertyname minimizzato,
ad esempio per id rimane id ma per username può diventare usn. 
Gli Id non devono essere mai nullable ma addirittura sempre con required.


esempio:

 public class Skill
    {
        [JsonPropertyName("id")]
        public required Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("desc")]
        public string? Description { get; set; }
    }
