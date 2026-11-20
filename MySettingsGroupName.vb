
Namespace My
    ' Classe ajoutée pour contourner le bug sur la lecture du config, dixit ChatGPT
    'il s'agit de lui indiquer qu'il doit lire et ecrire les paramètres dans Crodip_agent.MySettings et non dans Crodip_agent.My.MySettings
    'NO COMPRENDO !!!

    <Global.System.Configuration.SettingsGroupName("Crodip_agent.MySettings")>
    Partial Public NotInheritable Class MySettings

    End Class

End Namespace
