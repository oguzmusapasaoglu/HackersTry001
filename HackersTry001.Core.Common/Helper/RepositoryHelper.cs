using HackersTry001.Core.Common.Base;

public class RepositoryHelper
{
    public static ResponseBase<T> ReturnErrorResponse<T>
        (string erorMessage,
        ResultEnum resultType = ResultEnum.Error)
    where T : class
    {
        var response = new ResponseBase<T>();
        response.Message = erorMessage;
        response.Result = resultType;
        return response;
    }
}
