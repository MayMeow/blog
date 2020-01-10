using System.ComponentModel.DataAnnotations.Schema;
using MayMeow.Blog.Entities.Taxonomy;

namespace MayMeow.Blog.Entities.Content
{
    public class LabelNode
    {
        public int Id { get; set; }
        public int LabelId { get; set; }
        public int NodeId { get; set; }
        
        [ForeignKey("LabelId")]
        public Label Label { get; set; }
        [ForeignKey("NodeId")]
        public Node Node { get; set; }
    }
}