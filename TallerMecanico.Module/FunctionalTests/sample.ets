;#DropDB TallerMecanicoEasyTest

#Application TallerMecanico.Win
#Application TallerMecanico.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef TallerMecanico.Win

*Action About...
 
*Action OK

#EndIf

#IfDef TallerMecanico.Web

*Action Choose Theme(Black Glass)

#EndIf
