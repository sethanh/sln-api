const { execSync } = require('child_process');

const askQuestions = async () => {
    const { default: inquirer } = await import('inquirer');

    return await inquirer.prompt([
        {
            name: 'migrationName',
            type: 'input',
            message: 'What is the name of the migration?'
        }
    ]);
};

module.exports = async (app) => {
    const answers = await askQuestions();
    const { migrationName } = answers;
    const command = `dotnet ef migrations add ${migrationName} --project Sln.${app}/Sln.${app}.Migrator --startup-project Sln.${app}/Sln.${app}.Migrator`;

    execSync(command, { stdio: 'inherit' });
};
