namespace BlazorApp.Data;
using System.Collections.Generic;

public class HistoryService
{
    public static List<History> Histories { get; set; } = new List<History>();

    public Task<History[]> GetMyHistory(string name)
    {
        var myHistory = Histories.Where(h => h.Name == name).ToArray();
        return Task.FromResult(myHistory);
    }
    public Task<Summary[]> GetSummary()
    {
        var otherStory = Histories.GroupBy(h => h.Name);
        var result = new Summary[otherStory.Count()];
        for (int i = 0; i < otherStory.Count(); i++)
        {
            var thisElement = otherStory.ElementAt(i);
            result[i] = new Summary(){ Name = thisElement.Key, Count = thisElement.Count() };
        }
        return Task.FromResult(result);
    }
}
