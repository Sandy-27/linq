namespace assign2
{
    class program
    {
        static void Main(string[] args)
        {
            basic basic =new basic();
            basic.productData();
            
            // basic.containsinList();
            // samplejson sample=new samplejson();
            // sample.studenDetail();

            IList<EmployeeDatail> employeeDatails = new List<EmployeeDatail>(){
new EmployeeDatail(){EmployeeID=1,FirstName="Vikas",LastName="Ahlawat",Salary=33000},
new EmployeeDatail(){EmployeeID=2,FirstName="nikita",LastName="Jain",Salary=33000},
new EmployeeDatail(){EmployeeID=3,FirstName="Ashish",LastName="Kumar",Salary=33000},
new EmployeeDatail(){EmployeeID=4,FirstName="Nikhil",LastName="shama",Salary=33000},
new EmployeeDatail(){EmployeeID=5,FirstName="anish",LastName="Kadian",Salary=33000},
            };

            IList<ProjectDetail> projectDatails = new List<ProjectDetail>(){
new ProjectDetail(){ProjectDetailId=1,EmployeeDetailId=1,ProjectName="Task Track"},
new ProjectDetail(){ProjectDetailId=2,EmployeeDetailId=1,ProjectName="CLP"},
new ProjectDetail(){ProjectDetailId=3,EmployeeDetailId=1,ProjectName="Survey Management"},
new ProjectDetail(){ProjectDetailId=4,EmployeeDetailId=2,ProjectName="HR Management"},
new ProjectDetail(){ProjectDetailId=6,EmployeeDetailId=3,ProjectName="GRS"},
new ProjectDetail(){ProjectDetailId=7,EmployeeDetailId=3,ProjectName="DDS"},
new ProjectDetail(){ProjectDetailId=8,EmployeeDetailId=4,ProjectName="HR Management"},
new ProjectDetail(){ProjectDetailId=9,EmployeeDetailId=6,ProjectName="GL Management"},
            };

            

            //innerjoin
            var innerJoin = employeeDatails.Join(projectDatails,
            a => a.EmployeeID,
            b => b.EmployeeDetailId,
            (employee, project) => new { employee, project })
            .GroupBy(c => new { c.employee.FirstName })
            .OrderBy(d => d.Key.FirstName)
            .SelectMany(f => f.Select(p => new
            {
                FirstName = f.Key.FirstName,
                ProjectName = p.project.ProjectName
            }));
            foreach (var result in innerJoin)   
            {
                Console.WriteLine($"{result}");
            }

            //rightjoin
            var rightJoin = projectDatails.GroupJoin(employeeDatails,
            a => a.EmployeeDetailId,
            b => b.EmployeeID,
            (project, employee) => new { project, employee })
              .SelectMany(f => f.employee.DefaultIfEmpty(),
              (f,p) => new
              {
                  FirstName = p?.FirstName,
                  ProjectName = f.project.ProjectName,
              }
              )
              .OrderBy(d => d.FirstName);
            foreach (var result in rightJoin)
            {
                Console.WriteLine($"{result}");
            }

             //leftjoin
            var leftJoin = employeeDatails.GroupJoin(projectDatails,
            a => a.EmployeeID,
            b => b.EmployeeDetailId,
            (employee, project) => new { employee, project })
              .SelectMany(f => f.project.DefaultIfEmpty(),
              (f,p) => new
              {
                  ProjectName = p?.ProjectName,
                  FirstName = f.employee.FirstName,
              }
              )
              .OrderBy(d => d.FirstName);
            foreach (var result in rightJoin)
            {
                Console.WriteLine($"{result}");
            }

        }
        public class EmployeeDatail
        {
            public int EmployeeID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public float Salary { get; set; }
            public DateTime JoiningDate { get; set; }
            public string? Gender { get; set; }
        }
        public class ProjectDetail
        {
            public int ProjectDetailId { get; set; }
            public int EmployeeDetailId { get; set; }
            public string? ProjectName { get; set; }
 }}
    }