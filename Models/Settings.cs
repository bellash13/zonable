namespace zonable.Models;

public class Settings{
    public string SettingId { get; set; } = string.Empty;
    public string TimeZone { get; set; } = TimeZoneInfo.Utc.Id;
}