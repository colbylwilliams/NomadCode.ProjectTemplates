//using System;
//using MonoDevelop.Core;
//using MonoDevelop.Ide.Projects;
//using MonoDevelop.Ide.Templates;
//using MonoDevelop.Projects;

//namespace NomadCode.ProjectTemplates.Wizards
//{
//	public class NativeAppTemplateWizardPage : WizardPage
//	{
//		readonly string title = GettextCatalog.GetString ("Configure your Multiplatform Library");
//		readonly NativeAppTemplateWizard wizard;
//		//GtkProjectConfigurationWidget view;
//		string libraryName = string.Empty;
//		string description = string.Empty;
//		bool isAndroidChecked;
//		bool isIOSChecked;
//		bool isSharedProjectSelected;
//		bool isPortableClassLibrarySelected;
//		bool createNuGetProject;

//		public NativeAppTemplateWizardPage (NativeAppTemplateWizard wizard)
//		{
//			this.wizard = wizard;

//			//wizard.Parameters ["PackageAuthors"] = AuthorInformation.Default.Name;
//			wizard.Parameters ["PackageVersion"] = "1.0.0";

//			IsAndroidEnabled = Services.ProjectService.CanCreateProject ("C#", "MonoDroid");
//			IsIOSEnabled = Services.ProjectService.CanCreateProject ("C#", "XamarinIOS");

//			IsAndroidChecked = true;
//			IsIOSChecked = true;
//			IsSharedProjectSelected = true;
//			IsPortableClassLibrarySelected = false;
//			CreateNuGetProject = true;
//		}

//		public override string Title
//		{
//			get { return title; }
//		}

//		//protected override object CreateNativeWidget<T> ()
//		//{
//		//	if (view == null)
//		//		view = new GtkCrossPlatformLibraryProjectTemplateWizardPageWidget (this);

//		//	return view;
//		//}

//		//protected override void Dispose (bool disposing)
//		//{
//		//	if (view != null)
//		//	{
//		//		view.Dispose ();
//		//		view = null;
//		//	}
//		//}

//		void UpdateCanMoveNext ()
//		{
//			CanMoveToNextPage = IsValidLibraryName () &&
//				!string.IsNullOrEmpty (description) &&
//				ValidPlatformsSelected ();
//		}

//		bool IsValidLibraryName ()
//		{
//			LibraryNameError = null;

//			if (string.IsNullOrEmpty (libraryName))
//			{
//				return false;
//			}

//			return true;
//		}

//		bool ValidPlatformsSelected ()
//		{
//			if (isSharedProjectSelected)
//			{
//				return isAndroidChecked || isIOSChecked;
//			}

//			return true;
//		}

//		public string LibraryName
//		{
//			get { return libraryName; }
//			set
//			{
//				libraryName = value.Trim ();
//				wizard.Parameters ["PackageId"] = libraryName;
//				wizard.Parameters ["ProjectName"] = NewProjectConfiguration.GenerateValidProjectName (libraryName);
//				UpdateCanMoveNext ();
//			}
//		}

//		public string LibraryNameError { get; private set; }

//		public bool HasLibraryNameError ()
//		{
//			return !string.IsNullOrEmpty (LibraryNameError);
//		}

//		public string Description
//		{
//			get { return description; }
//			set
//			{
//				description = value.Trim ();
//				wizard.Parameters ["PackageDescription"] = description;
//				UpdateCanMoveNext ();
//			}
//		}

//		public bool IsIOSEnabled { get; private set; }

//		public bool IsIOSChecked
//		{
//			get { return isIOSChecked; }
//			set
//			{
//				isIOSChecked = value && IsIOSEnabled;
//				UpdateCreateIOSProjectParameter ();
//				UpdateCanMoveNext ();
//			}
//		}

//		void UpdateCreateIOSProjectParameter ()
//		{
//			wizard.Parameters ["CreateIOSProject"] = (isIOSChecked && !isPortableClassLibrarySelected).ToString ();
//		}

//		public bool IsAndroidEnabled { get; private set; }

//		public bool IsAndroidChecked
//		{
//			get { return isAndroidChecked; }
//			set
//			{
//				isAndroidChecked = value && IsAndroidEnabled;
//				UpdateCreateAndroidProjectParameter ();
//				UpdateCanMoveNext ();
//			}
//		}

//		void UpdateCreateAndroidProjectParameter ()
//		{
//			wizard.Parameters ["CreateAndroidProject"] = (isAndroidChecked && !isPortableClassLibrarySelected).ToString ();
//		}

//		public bool IsPortableClassLibrarySelected
//		{
//			get { return isPortableClassLibrarySelected; }
//			set
//			{
//				isPortableClassLibrarySelected = value;
//				CreateNuGetProject = !isPortableClassLibrarySelected;
//				isSharedProjectSelected = !isPortableClassLibrarySelected;
//				UpdateTemplateParameters ();
//				UpdateCanMoveNext ();
//			}
//		}

//		public bool IsSharedProjectSelected
//		{
//			get { return isSharedProjectSelected; }
//			set
//			{
//				isSharedProjectSelected = value;
//				isPortableClassLibrarySelected = !isSharedProjectSelected;
//				UpdateTemplateParameters ();
//				UpdateCanMoveNext ();
//			}
//		}

//		void UpdateTemplateParameters ()
//		{
//			wizard.Parameters ["CreateSharedProject"] = isSharedProjectSelected.ToString ();
//			wizard.Parameters ["CreatePortableProject"] = isPortableClassLibrarySelected.ToString ();

//			UpdateCreateAndroidProjectParameter ();
//			UpdateCreateIOSProjectParameter ();
//		}

//		bool CreateNuGetProject
//		{
//			get { return createNuGetProject; }
//			set
//			{
//				createNuGetProject = value;
//				wizard.Parameters ["CreateNuGetProject"] = createNuGetProject.ToString ();
//			}
//		}
//	}
//}