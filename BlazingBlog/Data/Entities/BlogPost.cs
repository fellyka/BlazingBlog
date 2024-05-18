using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazingBlog.Data.Entities;

public class BlogPost
{
	[Key]
	public int Id { get; set; }

	[Required, MaxLength(120)]
	public string? Title { get; set; }

	[Required, MaxLength(150)]
	public string? Slug { get; set; }

	[Required, MaxLength(250)]
	public string? IntroductionText { get; set; }
	[Required]
	public string? Content { get; set; }
    public bool IsPublished { get; set; }
	public DateTime PublishedOn { get; set; }
	public DateTime CreatedOn { get; set; }
	public DateTime ModifiedOn { get; set;}

	/*CategoryId and UserId are navigation properties*/
	public int CategoryId { get; set; }
	public int UserId { get; set; }

	/*Make these properties virtual to allow Lazyloading*/
	public virtual Category? Category { get; set; }
	public virtual User? User { get; set; }

}
