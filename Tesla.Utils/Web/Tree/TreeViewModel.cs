﻿namespace Tesla.Utils
{
    /// <summary>
    /// 树视图
    /// </summary>
    public class TreeViewModel
    {
        public string ParentId { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int? CheckState { get; set; }
        public bool ShowCheck { get; set; }
        public bool Complete { get; set; }
        public bool IsExpand { get; set; }
        public bool HasChildren { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
    }
}
