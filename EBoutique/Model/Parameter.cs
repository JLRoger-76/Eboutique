
namespace EBoutique.Model
{
    public class Parameter
    {
        public int CategoryId { get; set; }
        public int ProductsByPage { get; set; }
        public int Sort { get; set; }
        public int CurrentPage { get; set; }
        public string SearchTerm { get; set; }
        public Parameter(int categoryId, int productsByPage, int sort, int currentPage, string searchTerm)
        {
            CategoryId = categoryId;
            ProductsByPage = productsByPage;
            Sort = sort;
            CurrentPage = currentPage;
            SearchTerm = searchTerm;
        }
    }
}