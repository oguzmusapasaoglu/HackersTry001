namespace HackersTry001.Core.Common.Base
{
    public interface IFilter<TModel>
        where TModel : class
    {
        ResponseBase<TModel> GetAll();
    }
}
