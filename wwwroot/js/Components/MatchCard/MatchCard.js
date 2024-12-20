class MatchCard extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        const date = this.getAttribute('date');
        const homeTeam = this.getAttribute('homeTeam');
        const homeTeamLogo = this.getAttribute('homeTeamLogo');

        const awayTeam = this.getAttribute('awayTeam');
        const awayTeamLogo = this.getAttribute('awayTeamLogo');

        const odds1 = this.getAttribute('odds1');
        const odds0 = this.getAttribute('odds0');
        const odds2 = this.getAttribute('odds2');

        const styles = `
            <style>
                .fc-container {
                    display: flex;
                    flex-direction: column;
                    padding: 6px;
                    border: 2px solid #ccc;
                    border-radius: 10px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }

                .fc-row {
                    display: flex;
                    margin-bottom: 3px;
                }

                .fc-date {
                    width: 150px;
                    font-weight: bold;
                    margin-right: 20px;
                    color: #939393ee;
                    font-size: 12px;
                }

                .fc-logo {
                    width: 30px;
                    height: 30px;
                    background-color: lightgray;
                    margin-right: 20px;
                    border-radius: 50%;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    overflow: hidden;
                }

                    .fc-logo img {
                        width: 100%;
                        height: 100%;
                        object-fit: cover;
                    }

                .fc-name {
                    flex: 1;
                    display: flex;
                    align-items: center;
                    font-weight: bold;
                }

                .fc-oddvalue {
                    flex: 1 1 10%;
                    display: flex;
                    padding: 6px;
                    border: 2px solid #ccc;
                    border-radius: 10px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                    justify-content: space-between;
                }

                .left {
                  margin:0;
                }

                .right {
                    margin: 0;
                }
            </style>
        `;
        this.shadowRoot.innerHTML =
            ` ${styles} <div class="Mcard">
                 <div class="fc-container">
                                <div class="fc-row">
                                    <div class="fc-date"> ${date}</div>
                                </div>

                                <div class="fc-row">
                                    <div class="fc-logo">
                                        <img src="${homeTeamLogo}" alt="${homeTeam}" />
                                    </div>
                                    <div class="fc-name">${homeTeam}</div>
                                </div>

                                <div class="fc-row">
                                    <div class="fc-logo">
                                        <img src="${awayTeamLogo}" alt="${awayTeam}" />
                                    </div>
                                    <div class="fc-name">${awayTeam}</div>
                                </div>

                                <div class="fc-row">

                                    <div class="fc-oddvalue">
                                        <p class="left">0</p>
                                        <p class="right">0.0</p>
                                    </div>

                                    <div class="fc-oddvalue">
                                        <p class="left">0</p>
                                        <p class="right">0.0</p>
                                    </div>

                                    <div class="fc-oddvalue">
                                        <p class="left">0</p>
                                        <p class="right">0.0</p>
                                    </div>
                                </div>
                            </div>`;
    }
}

// Define the custom element
customElements.define('match-card', MatchCard);