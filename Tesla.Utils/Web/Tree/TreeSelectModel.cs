namespace Tesla.Utils
{
    /// <summary>
    /// 树形下拉框
    /// </summary>
    public class TreeSelectModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parentId { get; set; }
        public object data { get; set; }
    }
}
