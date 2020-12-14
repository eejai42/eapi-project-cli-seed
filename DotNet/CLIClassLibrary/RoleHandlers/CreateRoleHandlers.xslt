<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:variable name="smq" select="document('Lexicon.smql')" />
    <xsl:output method="xml" indent="yes"/>

    <xsl:include href="../CommonXsltTemplates.xslt"/>
    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <xsl:for-each select="/EAPIConfig/ProjectRoles">
                    <xsl:variable name="role-name" select="Name" />
                    <FileSetFile>
                        <RelativePath>
                            <xsl:value-of select="Name"/>
                            <xsl:text>CLIHandler.cs</xsl:text>
                        </RelativePath>
                        <OverwriteMode>Never</OverwriteMode>
                        <xsl:element name="FileContents" xml:space="preserve">using Newtonsoft.Json;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class <xsl:value-of select="Name"/>CLIHandler : RoleHandlerBase&lt;SMQ<xsl:value-of select="Name"/>>
    {

        public <xsl:value-of select="Name"/>CLIHandler(string amqps, string accessToken)
            : base(new SMQ<xsl:value-of select="Name"/>(amqps), accessToken)
        {
        }

        public override string Handle(string invoke, string data, string where)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            string result = HandlerFactory(invoke, data, where);
            return result;
        }
    }
}</xsl:element>
                        <FileSetFile>
                            <RelativePath>
                                <xsl:value-of select="Name"/>
                                <xsl:text>CLIHandler.designer.cs</xsl:text>
                            </RelativePath>
                            <xsl:element name="FileContents" xml:space="preserve">using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class <xsl:value-of select="Name"/>CLIHandler
    {
        private string HandlerFactory(string invokeRequest, string payloadString, string where)
        {
            var result = "";
            var payload = JsonConvert.DeserializeObject&lt;StandardPayload>(payloadString);
            payload.SetActor(this.SMQActor);
            payload.AccessToken = this.SMQActor.AccessToken;
            payload.AirtableWhere = where;

            switch (invokeRequest.ToLower())
            {<xsl:for-each select="$smq//SMQMessages/SMQMessage[ActorFrom = $role-name]">
                case "<xsl:value-of select="translate(Name, $ucletters, $lcletters)"/>":
                    this.SMQActor.<xsl:value-of select="Name"/>(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   
</xsl:for-each>
                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
    }
}
</xsl:element>
                        </FileSetFile>
                    </FileSetFile>
                </xsl:for-each>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>SomeFile.txt</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">Role:
                    <xsl:for-each select="/EAPIConfig/ProjectRoles">
                        -- <xsl:value-of select="Name"/>
                    </xsl:for-each>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
