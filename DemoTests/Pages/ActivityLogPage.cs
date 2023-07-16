
namespace TestWebClient
{
    public class ActivityLogPage : BasePage
    {
        public DropDownMenu DropDownMenu = new DropDownMenu();

        public DataGrid LogRecords
        {
            get 
            {
                return new DataGrid();
            }
        }

        public ActivityLogPage() : base()
        {
        }

    }
}
