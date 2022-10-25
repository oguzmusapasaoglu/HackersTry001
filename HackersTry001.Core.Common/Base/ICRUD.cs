namespace HackersTry001.Core.Common.Base
{
    public interface ICRUD<TModel>
        where TModel : class
    {
        ResponseBase<TModel> Create(TModel request);
        ResponseBase<TModel> Update(TModel request);
        ResponseBase<TModel> Delete(TModel request);
    }
}
