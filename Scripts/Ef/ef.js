#!/bin/node

const { execSync } = require('child_process');
const addMigration = require('./addMigration');

const apps = [
    'Management',
];

const askQuestions = async () => {
    const { default: inquirer } = await import('inquirer');

    const migrationActions = [
        { name: ' Add Migration', value: 'Add' },
        { name: ' Remove Migration', value: 'Remove' },
    ];

    const databaseActions = [
        { name: ' Update DataBase', value: 'Update' }
    ];

    return await inquirer.prompt([
        {
            type: 'list',
            name: 'app',
            message: 'Select app',
            choices: apps,
            validate: (value) => {
                if (!value.length) {
                    return 'Please select app name';
                }
                return true;
            }
        },
        {
            name: 'action',
            type: 'list',
            message: 'What do you want to do?',
            choices: [
                new inquirer.Separator('Migrations:'),
                ...migrationActions,
                new inquirer.Separator('Database:'),
                ...databaseActions,
            ],
        },
    ]);
};

askQuestions().then(async (answers) => {
    const { app, action } = answers;

    if (action === 'Add') {
        await addMigration(app);
    }

    if (action === 'Remove') {
        const command = `dotnet ef migrations remove --project Sln.${app}/Sln.${app}.Migrator --startup-project Sln.${app}/Sln.${app}.Migrator`;
        execSync(command, { stdio: 'inherit' });
    }

    if (action === 'Update') {
        const command = `dotnet ef database update --project Sln.${app}/Sln.${app}.Migrator --startup-project Sln.${app}/Sln.${app}.Migrator`;
        execSync(command, { stdio: 'inherit' });
    }
});