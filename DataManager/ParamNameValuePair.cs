namespace DataManager
{
    public class ParamNameValuePair
    {
        public ParamNameValuePair(string pName, object pValue)
        {
            ParameterName = pName;
            parameterValue = pValue;
        }
        public string ParameterName { get; set; }
        public object parameterValue { get; set; }
    }

}