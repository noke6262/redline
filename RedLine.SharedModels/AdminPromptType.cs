namespace RedLine.SharedModels;

public enum AdminPromptType : byte
{
	AllowAll,
	DimmedPromptWithPasswordConfirmation,
	DimmedPrompt,
	PromptWithPasswordConfirmation,
	Prompt,
	DimmedPromptForNonWindowsBinaries
}
