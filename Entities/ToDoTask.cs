using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace ToDoApp.Entities;

public class ToDoTask
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }
}
