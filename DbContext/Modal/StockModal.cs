using Persistence.Modal.Common;

namespace WebApies.Modal
{

    public class Stock: CommonModel
    {
        public int UpdatedPrice { get; set; }
        public string Symbol { get; set; }
    }
}
