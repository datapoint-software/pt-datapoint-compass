const process = require("child_process");
const fs = require("fs");

process.execSync("npm run ng extract-i18n -- --format json --output-path messages");

const source = JSON.parse(
  fs.readFileSync("messages/messages.json")
);

for (const languageCode of [ "pt" ]) {

  const target = JSON.parse(
    fs.readFileSync(
      `messages/messages.${languageCode}.json`,
      "utf-8"
    )
  );

  for (const id of Object.keys(source.translations)) {
    if (target.translations[id] === undefined) {
      console.log(`+ ${id}`);
      target.translations[id] = `%${source.translations[id]}%`;
    }
  }

  for (const id of Object.keys(target.translations)) {
    if (source.translations[id] === undefined) {
      console.log(`- ${id}`);
      delete target.translations[id];
    }
  }

  target.translations = Object.keys(target.translations)
    .sort((a, b) => a.localeCompare(b))
    .reduce((pv, cv) => ({ ...pv, [cv]: target.translations[cv] }), {});

  fs.writeFileSync(
    `messages/messages.${languageCode}.json`,
    JSON.stringify(target, null, 2),
    { encoding: "utf-8" }
  );
}
