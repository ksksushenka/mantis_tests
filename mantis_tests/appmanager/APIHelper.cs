using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }
        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");
            Mantis.ProjectData[] priojectsback = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<ProjectData> projects = new List<ProjectData>();

            foreach (Mantis.ProjectData projectback in priojectsback)
            {
                ProjectData project = new ProjectData(projectback.name);
                projects.Add(project);
            }

            return projects;
        }
        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Username, account.Password, project);
        }
    }
}
