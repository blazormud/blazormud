namespace BlazorMUD.Core.Models
{
    public interface IInstanceModel<TTemplate>
    {
        long Id { get; set; }
        long TemplateId { get; set; }
        TTemplate Template { get; set; }
    }
}
