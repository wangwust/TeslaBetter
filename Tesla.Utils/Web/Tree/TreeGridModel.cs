namespace Tesla.Utils
{
    /// <summary>
    /// 树形表格  不可随意更新熟悉属性名称
    /// </summary>
    public class TreeGridModel
    {
        public string id { get; set; }
        public string parentId { get; set; }
        public string text { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public bool loaded { get; set; }
        public string entityJson { get; set; }
    }
}
