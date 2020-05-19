namespace legodb.Models
{
  public class Set
  {
    public int Id { get; set; }
    public string Title { get; set; }
  }


  //NOTE this is for our Many-To-Many table
  public class SetLego
  {
    public int Id { get; set; }
    public int LegoId { get; set; }
    public int SetId { get; set; }
    //NOTE if i wanted to control by a user as well
    // public string CreatorEmail { get; set; }
  }
}