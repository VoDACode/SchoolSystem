const https = require('https');
// import faker.js
const faker = require('@faker-js/faker').faker;
process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = 0;
faker.locale = 'uk';


(async function () {
    let mode = "PARRENT";
    for (let i = 0; i < 1000; i++) {

        await sleep(75);

        let obj = {};

        if (mode == "STUDENT") {
            obj = {
                DateOfEntry: faker.date.past(),
                FirstName: faker.name.firstName(),
                LastName: faker.name.lastName(),
                MiddleName: faker.name.middleName(),
                Email: faker.internet.email(),
                Phone: faker.phone.number(),
                Street: faker.address.street(),
                City: faker.address.city(),
                Settlement: faker.address.state(),
                BirthDate: faker.date.past(),
                Region: faker.address.state(),
                Area: faker.address.state(),
                Country: faker.address.country(),
                House: faker.random.numeric(4),
            }
        } else if (mode == "TEACHER") {
            obj = {
                BirthDate: faker.date.past(),
                FirstName: faker.name.firstName(),
                LastName: faker.name.lastName(),
                MiddleName: faker.name.middleName(),
                Email: faker.internet.email(),
                Phone: faker.phone.number(),
                DateStartWork: faker.date.past(),
            }
        } else if (mode == "PARRENT") {
            obj = {
                DateOfEntry: faker.date.past(),
                FirstName: faker.name.firstName(),
                LastName: faker.name.lastName(),
                MiddleName: faker.name.middleName(),
                Email: faker.internet.email(),
                Phone: faker.phone.number()
            }
        } 

        let content = JSON.stringify(obj);

        const options = {
            hostname: 'localhost',
            port: 44413,
            path: '/api/users/parent',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },

        };

        const req = https.request(options, (res) => {
            console.log(`statusCode [${i + 1}]: ${res.statusCode}`);
            res.on('data', (d) => {
                process.stdout.write(d);
            });
        })
        req.write(content);
        req.end();
    }
})();
// sleep fubction
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}