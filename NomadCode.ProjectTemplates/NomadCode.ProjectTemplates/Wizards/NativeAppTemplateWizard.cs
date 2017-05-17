//using System;
//using System.Collections.Generic;
//using System.Linq;
//using MonoDevelop.Core.StringParsing;
//using MonoDevelop.Ide.Templates;
//using MonoDevelop.Projects;

//namespace NomadCode.ProjectTemplates.Wizards
//{
//	public class NativeAppTemplateWizard : TemplateWizard
//	{
//		public override string Id
//		{
//			get { return "NomadCode.ProjectTemplates.NativeAppTemplateWizard"; }
//		}

//		public override WizardPage GetPage (int pageNumber)
//		{
//			return new NativeAppTemplateWizardPage (this);
//		}

//		public override void ItemsCreated (IEnumerable<IWorkspaceFileObject> items)
//		{
//			string projectName = Parameters ["ProjectName"];
//			var libraryProjects = GetLibraryProjects (items).ToList ();

//			//foreach (DotNetProject project in libraryProjects)
//			//{
//			//	project.SetOutputAssemblyName (projectName);
//			//}

//			//if (Parameters.GetBoolValue ("CreatePortableProject"))
//			//{
//			//	AddNuGetPackageMetadataToPclProject (libraryProjects);
//			//}

//			SaveAsync (libraryProjects);
//		}

//		IEnumerable<DotNetProject> GetLibraryProjects (IEnumerable<IWorkspaceFileObject> items)
//		{
//			Solution solution = items.OfType<Solution> ().FirstOrDefault ();
//			if (solution != null)
//			{
//				return GetLibraryProjects (solution.GetAllProjects ());
//			}

//			return items.OfType<DotNetProject> ().Where (p => !(p is PackagingProject));
//		}

//		//void AddNuGetPackageMetadataToPclProject (IEnumerable<DotNetProject> projects)
//		//{
//		//	var pclProject = projects.FirstOrDefault (p => p.IsPortableLibrary);
//		//	if (pclProject != null)
//		//	{
//		//		var metadata = new NuGetPackageMetadata ();
//		//		metadata.Id = Parameters ["PackageId"];
//		//		metadata.Description = Parameters ["PackageDescription"];
//		//		metadata.Version = Parameters ["PackageVersion"];
//		//		metadata.Authors = Parameters ["PackageAuthors"];

//		//		metadata.UpdateProject (pclProject);
//		//	}
//		//}

//		protected virtual void SaveAsync (IEnumerable<SolutionItem> projects)
//		{
//			IdeApp.ProjectOperations.SaveAsync (projects);
//		}
//	}
//}