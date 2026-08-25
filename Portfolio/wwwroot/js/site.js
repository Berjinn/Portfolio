const text = (element, value) => { element.textContent = value ?? ""; };

async function loadPortfolio() {
    const response = await fetch("/api/portfolio");
    if (!response.ok) throw new Error("Unable to load portfolio data.");
    return response.json();
}

function renderSkills(skills) {
    const container = document.querySelector("#skills");
    container.replaceChildren(...skills.map(({ category, items }) => {
        const group = document.createElement("div");
        group.className = "skill-group";
        const label = document.createElement("span");
        const content = document.createElement("p");
        text(label, category);
        text(content, items.join(" · "));
        group.append(label, content);
        return group;
    }));
}

function renderExperience(items) {
    const container = document.querySelector("#experience-list");
    const template = document.querySelector("#experience-template");
    container.replaceChildren(...items.map(item => {
        const node = template.content.cloneNode(true);
        text(node.querySelector(".experience-period"), item.period);
        text(node.querySelector(".experience-location"), item.location);
        text(node.querySelector(".experience-role"), item.role);
        text(node.querySelector(".experience-company"), item.company);
        text(node.querySelector(".experience-description"), item.description);
        const highlights = node.querySelector(".experience-highlights");
        item.highlights.forEach(highlight => {
            const listItem = document.createElement("li");
            text(listItem, highlight);
            highlights.append(listItem);
        });
        return node;
    }));
}

function renderProjects(items) {
    const container = document.querySelector("#project-list");
    const template = document.querySelector("#project-template");
    container.replaceChildren(...items.map((item, index) => {
        const node = template.content.cloneNode(true);
        text(node.querySelector(".project-number"), String(index + 1).padStart(2, "0"));
        text(node.querySelector(".project-name"), item.name);
        text(node.querySelector(".project-description"), item.description);
        const technologies = node.querySelector(".project-tech");
        item.technologies.forEach(technology => {
            const listItem = document.createElement("li");
            text(listItem, technology);
            technologies.append(listItem);
        });
        const link = node.querySelector(".project-link");
        const destination = item.liveUrl || item.repositoryUrl;
        if (destination) link.href = destination;
        else link.remove();
        return node;
    }));
}

loadPortfolio().then(profile => {
    document.title = `${profile.name} | Portfolio`;
    text(document.querySelector("#hero-title"), profile.headline);
    text(document.querySelector("#summary"), profile.summary);
    text(document.querySelector("#location"), profile.location);
    text(document.querySelector("#footer-name"), profile.name);
    document.querySelector(".brand").firstChild.textContent = profile.name.split(" ").map(word => word[0]).join("").slice(0, 2);
    ["#email-link", "#footer-email-link"].forEach(selector => {
        document.querySelector(selector).href = `mailto:${profile.contact.email}`;
    });
    [["#github-link", profile.contact.gitHubUrl], ["#linkedin-link", profile.contact.linkedInUrl]].forEach(([selector, url]) => {
        const link = document.querySelector(selector);
        if (url) link.href = url;
        else link.remove();
    });
    renderSkills(profile.skills);
    renderExperience(profile.experience);
    renderProjects(profile.projects);
}).catch(() => {
    text(document.querySelector("#summary"), "Portfolio information is temporarily unavailable. Please try again shortly.");
});

text(document.querySelector("#year"), new Date().getFullYear());
