function Fix-WhiteNamespace() {
	$find = $dte.Find;
	$find.WaitForFindToComplete = $true;

	$find.FindReplace(
		[EnvDTE.vsFindAction]::vsFindActionReplaceAll, 
		"White.Core",
		[EnvDTE.vsFindOptions]::vsFindOptionsKeepModifiedDocumentsOpen,
		"TestStack.White", 
		[EnvDTE.vsFindTarget]::vsFindTargetSolution, "", "", 
		[EnvDTE.vsFindResultsLocation]::vsFindResults2);
}

Export-ModuleMember Fix-WhiteNamespace