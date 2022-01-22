namespace BlazorApp.Data;
using System.Resources;

public class ConverterService
{
    public static string UserName { get; set; } = "";
    public Task<Converter> ConvertAsync(Converter converter, string userName)
    {
        converter.Result = 0;
        string inputType = "";
        string outputType = "";
        switch (converter.UnitType)
        {
            case UnitType.Volume:
                {
                    if (converter.InputVolume == converter.ResultVolume)
                        converter.Result = converter.Input;
                    else
                    {
                        inputType = converter.InputVolume.ToString();
                        outputType = converter.ResultVolume.ToString();
                    }
                }
                break;
            case UnitType.Time:
                {
                    if (converter.InputTime == converter.ResultTime)
                        converter.Result = converter.Input;
                    else
                    {
                        inputType = converter.InputTime.ToString();
                        outputType = converter.ResultTime.ToString();
                    }
                }
                break;
            default:
                break;
        }

        if (converter.Result == 0)
        {
            if (double.TryParse(Resources.UnitValues.ResourceManager.GetString(inputType), out double factor))
            {
                var defaultUnit = converter.Input * factor;
                if (double.TryParse(Resources.UnitValues.ResourceManager.GetString(outputType), out factor))
                {
                    converter.Result = defaultUnit / factor;
                }
            }
        }
        if (!string.IsNullOrWhiteSpace(userName))
        {
            HistoryService.Histories.Add(new History()
            {
                Name = userName,
                Input = converter.Input
            ,
                InputType = inputType,
                ResultType = outputType,
                Result = converter.Result
            });
        }
        return Task.FromResult(converter);
    }
}
