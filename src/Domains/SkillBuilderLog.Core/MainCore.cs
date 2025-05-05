using RepositoryFramework;
using System.Text.Json.Serialization;

namespace SkillBuilderLog.Core
{
    public static class Helper
    {

        public static async Task<Skill> GetSkillAsync(string id, IRepository<Skill, string> repository)
        {
            //voglio inserire qui il repository pattern 
            var skill = await repository.GetAsync(id);
            skill.Id = Guid.NewGuid();
            return skill;

        }
        public static async Task<Session> GetSessionAsync(string id, IRepository<Session, string> repository)
        {
            //voglio inserire qui il repository pattern 
            var session = await repository.GetAsync(id);
            session.Id = Guid.NewGuid();
            return session;
        }
    }
    public class Skill
    {
        [JsonPropertyName("id")]
        public required Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("desc")]
        public string? Description { get; set; }
    }

    public class Session
    {
        [JsonPropertyName("id")]
        public required Guid Id { get; set; }

        [JsonPropertyName("skill")]
        public Skill? Skill { get; set; }

        [JsonPropertyName("dur")]
        public int? DurationInMinutes { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("cmt")]
        public string? Comment { get; set; }
    }

    public class User
    {
        [JsonPropertyName("id")]
        public required Guid Id { get; set; }

        [JsonPropertyName("usn")]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("skills")]
        public List<Skill>? Skills { get; set; }
    }
}