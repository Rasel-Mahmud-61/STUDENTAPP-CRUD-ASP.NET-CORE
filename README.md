# StudentApp (CRUD) 

#  Feature
<ul>
  <li> Insert</li>
 <li> Update</li>
  <li> Delete</li>
  
</ul>   

 
## Package 
<ul>
  <li> Microsoft.EntityFrameworkCore.SqlServer</li>
  <li>Microsoft.EntityFrameworkCore </li>
  <li> Microsoft.EntityFrameworkCore.Tools</li>
  
</ul>   

# Process 

##  ✍️ Create the Model
```

using System.ComponentModel.DataAnnotations;

namespace CRUDOFSTUDENT.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
    }
}
```

##  ✍️ Create ApplicationDbContext
```using CRUDOFSTUDENT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDOFSTUDENT.Data
{
    public class ApplicationDbContext:DbContext
    {

        // create connection wiht database of outside 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
          {
            
        }

        //  create table into the database

      public   DbSet<Student> HELLOAllStudents { get; set; }   

    }
}
```
##  ✍️  Create StudentController

```using CRUDOFSTUDENT.Data;
using CRUDOFSTUDENT.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOFSTUDENT.Controllers
{
    public class StudentController : Controller
    {

        public readonly ApplicationDbContext _Context;
        public StudentController(ApplicationDbContext context)
        {
            _Context = context;
        }

        //display form 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {

            if (ModelState.IsValid)
            {

                _Context.HELLOAllStudents.Add(student);
                _Context.SaveChanges();

                return RedirectToAction("Index");


            }
            return View(student);

        }
        [HttpGet]
        public IActionResult Index()
        {

            var students = _Context.HELLOAllStudents.ToList();
            return View(students);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var student = _Context.HELLOAllStudents.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();

            }
            return View(student);

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {

                _Context.HELLOAllStudents.Update(student);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _Context.HELLOAllStudents.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {

                NotFound();

            }
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _Context.HELLOAllStudents.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                _Context.HELLOAllStudents.Remove(student);
                _Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
```
##  ✍️ Create the View for Adding a Student 

## index view 

```



<div class="row">
     <div class="col-6">
         Display all student
     </div>
     <div class="col-6" mt-2>
         <form asp-controller="Student" asp-action="Add" method="get">
                <button type="submit" class="btn btn-primary">
                        AddStudent
                    </button>
         </form>
      
     </div>
</div>

<table class="table table-bordered">

    <thead>

        <tr>
            <th>ID</th>
            <th>Name</th>
            <th> Email</th>
            <th>Phone</th>
            <th>Action</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        @foreach(var student in Model)
        {
            <tr>
                <td>@student.Id</td>
                <td>@student.Name</td>
                <td>@student.Email</td>
                <td>@student.Phone</td>
             <td>
                 <a asp-controller="Student" asp-action="Edit" asp-route-id="@student.Id" class="btn btn-warning">Edit</a>
             </td>
               <td>
                 <a asp-controller="Student" asp-action="Delete" asp-route-id="@student.Id" class="btn btn-warning">Delete</a>
             </td>

            </tr>
        }

    </tbody>
</table>
```
## Add view   
```@model CRUDOFSTUDENT.Models.Entities.Student

<h2>add student into the table</h2>

<form asp-action="Add" method="post">


    <div class="mt-3">

        <label class="form-label">Name</label>
        <input asp-for="Name" type="text" class="form-control"/>
        <span asp-validation-for="Name" class="text-danger">

        </span>

    </div>

    <div class="mt-3">

        <label class="form-label">Email</label>
        <input asp-for="Email" type="email" class="form-control">
         <span asp-validation-for="Email" class="text-danger">
        </span>
    </div>
    <div class="mt-3">

        <label class="form-label">Phone</label>
        <input asp-for="Phone" type="text" class="form-control">
         <span asp-validation-for="Phone" class="text-danger">
        </span>
    </div>

    <button type="submit" class="btn mt-3 btn-primary">Add Student</button>

</form>


@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```
## Edit view 

```  @model CRUDOFSTUDENT.Models.Entities.Student

<h2>Edit student Details</h2>

<form asp-action="Edit" method="post">

    <div class="mt-3">
        <label asp-for="Name"class="form-label">Name
        </label>
        <input asp-for="Name" class="form-control" />
        
    </div>
    <div class="mt-3">
        <label asp-for="Email" class="form-label">
            Emai
        </label>
        <input asp-for="Email" class="form-control" />

    </div>
    <div class="mt-3">
        <label asp-for="Phone" class="form-label">
            Phone
        </label>
        <input asp-for="Phone" class="form-control" />


    </div>
    <button type="submit" class="btn btn-primary">save</button>
     <button type="submit" class="btn btn-primary">Back</button>
</form>
```
## Delete View
``` @model CRUDOFSTUDENT.Models.Entities.Student

<h1>Delete Student</h1>

<div>
    <h4>@Model.Name</h4>
    <p>Email: @Model.Email</p>
    <p>Phone: @Model.Phone</p>
</div>

<form asp-action="DeleteConfirmed" asp-controller="Student" method="post">
    <input type="hidden" name="id" value="@Model.Id" />
    <button type="submit" class="btn btn-danger">Delete</button>
    <a asp-action="Index" class="btn btn-secondary">Cancel</a>
</form>
```

## program.cs file for build all dependencies and services 

```using CRUDOFSTUDENT.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```


