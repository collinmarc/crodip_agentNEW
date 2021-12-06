'Imports System.Collections.Generic
'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions

'Public Class OleDbCommandExtensions
'    Public Shared Sub ConvertNamedParametersToPositionalParameters(command As OleDbCommand)
'        ''1. Find all occurrences of parameter references in the SQL statement (such as @MyParameter).
'        ''2. Find the corresponding parameter in the commands parameters list.
'        ''3. Add the found parameter to the newParameters list And replace the parameter reference in the SQL with a question mark (?).
'        ''4. Replace the commands parameters list with the newParameters list.

'        Dim newParameters = New List(Of OleDbParameter)()

'        command.CommandText = Regex.Replace(command.CommandText, "(@\\w*)", Match >=
'        {
'            Dim parameter = Command.Parameters.OfType < OleDbParameter > ().FirstOrDefault(a >= a.ParameterName == match.Groups[1].Value);
'            If (parameter! = null) Then
'                        {
'                var parameterIndex = newParameters.Count;

'                var newParameter = command.CreateParameter();
'                newParameter.OleDbType = parameter.OleDbType;
'                newParameter.ParameterName = "@parameter" + parameterIndex.ToString();
'                newParameter.Value = parameter.Value;

'                newParameters.Add(newParameter);
'            }

'            Return "?";
'        });

'        command.Parameters.Clear();
'        command.Parameters.AddRange(newParameters.ToArray());
'End Sub
'End Class