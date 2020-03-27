# Can I Haz T4 SQL?

## Goal
Use a SQL file as a runtime T4 template so that I can dynamically generate SQL with parameter values.

## Steps
1. Add reference to NuGet package System.CodeDom.
2. Add a new item to the project of type "Runtime Text Template", use a name suitable for a Class name. When your T4 template is compiled it generates a backing partial class with the same name automatically.
3. Right-click the T4 template (tt) file and select Properties. Then set the Custom Tool to TextTemplatingFilePreprocessor.
4. Add a new class under SqlTemplatePartials directory with the same name as your template.
5. Add the partial modifier to this class. This partial class is the non-generated half that you can modify safely.
6. Remove SqlTemplatePartials from the namespace. This partial class's namespace needs to be the same as the generated partial class's namespace.
7. Add all of your parameters to this partial class's constructor with public getter-only backing Properties. You may reference these Property names in your T4 template during step 9.
8. Renamed the T4 Template and change the extension from tt to sql.
9. Open the SQL/T4 (.sql) file and add SQL comments around or in front of the T4 directives (<#@...#>) at the top. The comment will appear in the final generated string, but the T4 directives will be removed. See examples.
10. Write your SQL in the new SQL/T4 file. you can use the T4 instructions however you like to generate the SQL commands that you need.
11. Write tests to verify the correct SQL is generated when you invoke TransformText() at runtime.
12. ???
13. Profit!
