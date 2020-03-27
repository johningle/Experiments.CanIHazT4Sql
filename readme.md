# Can I Haz T4 SQL?

## Goal of the Experiment
My goal is to use a SQL file as a runtime T4 template so that I can dynamically generate SQL with parametric replacement values.
This is the minimum necessary proof-of-concept I've identified so far.

## Steps to Success
I used the following steps to accomplish this goal:

1. Add reference to NuGet package System.CodeDom.
2. Add a new item to the project of type "Runtime Text Template", use a name suitable for a Class name. When your T4 template is compiled it generates a backing partial class with the same name automatically.
3. Right-click the T4 template (tt) file and select Properties. Then set the Custom Tool to TextTemplatingFilePreprocessor.
4. Add a new class under SqlTemplatePartials directory with the same name as your template. Technically, other options are viable. Your partial class file name must simply be different or in a differnt directory from that of the generated backing class for your T4 template.
5. Add the partial modifier to this class. This partial class is the non-generated half that you can modify safely without concern for the T4 preprocessor overwriting it.
6. Remove SqlTemplatePartials from the namespace. This partial class's namespace needs to be the same as the generated partial class's namespace. I chose to put the file in a subdirectory so the file names could be identical, then change my partial's namespace to violate the conventional namespace per subdirectory default.
7. Add all of your parameters to this partial class's constructor with public getter-only backing Properties. You may reference these Property names in your T4 template during step 9. This could, of course, support any form of value injection, not just constructor.
8. Renamed the T4 Template and change the extension from tt to sql. We rename before we open and edit so that Visual Studio will recognize the file extension and give us SQL tooling, including parsing and highlighting.
9. Open the SQL/T4 (.sql) file and add SQL comments around or in front of the T4 directives (<#@...#>) at the top. The comment will appear in the final generated string, but the T4 directives will be removed. See examples. The goal of this step is to ensure the contents of the SQL files are correctly parsable as SQL. If we did not comment the T4 directives, the SQL parser would complain about them. I used the opportunity to label the generated SQL with the filename in my comment block.
10. Write your SQL in the new SQL/T4 file. you can use the T4 instructions however you like to generate the SQL commands that you need.
11. Write tests to verify the correct SQL is generated when you invoke TransformText() at runtime. As a proof of concept, I'm most interested in proving this technique works, not best practices for unit testing SQL code. The duplicated of the SQL in the tests is wholly intentional but not something I would be eager to do in production code except while debugging my T4.
12. ???
13. Profit!

