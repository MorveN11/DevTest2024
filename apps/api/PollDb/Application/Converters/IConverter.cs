namespace PollDb.Application.Converters;

public interface IConverter<TFrom, TOut>
{
    TOut Convert(TFrom toConvert);
}
